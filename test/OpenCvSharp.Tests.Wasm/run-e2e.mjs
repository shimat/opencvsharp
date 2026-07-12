// Headless-browser driver for the wasm E2E consumer test (see .github/workflows/wasm.yml).
// Navigates to the published Blazor app and waits for #result's data-status to leave "running".
// A native module name mismatch (#2039) throws inside OnInitialized (status="error"); an
// OpenCL/UMat probe crash (#2037) either throws the same way or hangs the page forever, which
// the timeout below also treats as a failure.

import { chromium } from 'playwright';

const url = process.argv[2];
if (!url) {
  console.error('Usage: node run-e2e.mjs <url>');
  process.exit(1);
}

const TIMEOUT_MS = 60_000;

const browser = await chromium.launch();
const page = await browser.newPage();

const pageErrors = [];
page.on('pageerror', (err) => pageErrors.push(String(err)));
page.on('console', (msg) => {
  if (msg.type() === 'error') pageErrors.push(msg.text());
});

await page.goto(url, { waitUntil: 'load' });

let result = null;
const deadline = Date.now() + TIMEOUT_MS;

while (Date.now() < deadline) {
  result = await page
    .locator('#result')
    .evaluate((el) => ({ status: el.getAttribute('data-status'), text: el.textContent }))
    .catch(() => null);

  if (result && result.status !== 'running') {
    break;
  }
  await page.waitForTimeout(500);
}

await browser.close();

if (pageErrors.length > 0) {
  console.log('Browser console/page errors:');
  for (const e of pageErrors) console.log(' - ' + e);
}

if (!result || result.status === 'running') {
  console.error(
    `E2E test FAILED: #result never left "running" state within ${TIMEOUT_MS}ms. ` +
      'This is the symptom of a hung wasm runtime (see #2037: an OpenCL/UMat probe crash can hang the calling task instead of throwing).',
  );
  process.exit(1);
}

console.log(`result: ${result.status}: ${result.text}`);

if (result.status !== 'ok') {
  console.error(
    `E2E test FAILED (status=${result.status}). This is the symptom of a native binding regression ` +
      '(see #2039: P/Invoke module name mismatch -> DllNotFoundException, or #2037: OpenCL/UMat probe crash).',
  );
  process.exit(1);
}

console.log('E2E test passed.');
