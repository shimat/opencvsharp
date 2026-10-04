#!/usr/bin/env bash
set -euo pipefail

: "${ANDROID_TEST_RID:?Set ANDROID_TEST_RID}"
: "${GITHUB_RUN_NUMBER:?Set GITHUB_RUN_NUMBER}"

case "$ANDROID_TEST_RID" in
  android-x64) expected_arch=X64 ;;
  android-arm64) expected_arch=Arm64 ;;
  *) echo "Unsupported RID: $ANDROID_TEST_RID" >&2; exit 1 ;;
esac

project=test/OpenCvSharp.AndroidSmoke/OpenCvSharp.AndroidSmoke.csproj
dotnet restore "$project" \
  -p:AndroidCiVersion="$GITHUB_RUN_NUMBER" \
  -p:RuntimeIdentifier="$ANDROID_TEST_RID" \
  --source "$PWD/artifacts" \
  --source https://api.nuget.org/v3/index.json
dotnet publish "$project" -c Release -f net10.0-android \
  -p:AndroidCiVersion="$GITHUB_RUN_NUMBER" \
  -p:RuntimeIdentifier="$ANDROID_TEST_RID" \
  --no-restore

apk=$(find test/OpenCvSharp.AndroidSmoke/bin/Release -name '*Signed.apk' -print -quit)
if [[ -z "$apk" ]]; then
  echo "No signed Android APK was produced." >&2
  exit 1
fi

adb install -r "$apk"
adb logcat -c
adb shell monkey -p org.opencvsharp.smoke 1

for attempt in $(seq 1 90); do
  log=$(adb logcat -d -s OpenCvSharpSmoke:I '*:S')
  if grep -q 'FAIL:' <<< "$log"; then
    echo "$log" >&2
    exit 1
  fi
  if grep -q "PASS:$expected_arch" <<< "$log"; then
    echo "$log"
    exit 0
  fi
  sleep 1
done

echo "Timed out waiting for the $expected_arch managed smoke result." >&2
adb logcat -d -s OpenCvSharpSmoke:I '*:S' >&2
exit 1
