# .NET dependency update policy

The minimum target framework of a published NuGet package, its public package dependencies, and the SDK used to build and test it are separate compatibility decisions. Do not raise consumer requirements solely because a newer .NET release is available.

## Published packages

Keep the minimum target framework while it meets the library's API, performance, and maintenance needs. Review any increase explicitly, including the impact on existing consumers. A runtime reaching end of support is a reason to review the support policy, not an automatic reason to retarget the library: an older target framework can still be consumed on a newer supported runtime.

Keep public dependencies on the selected major version unless a feature, fix, or servicing requirement justifies a major upgrade. Review the dependency's actual supported target frameworks and transitive dependencies; its major version does not necessarily equal the minimum .NET runtime version. Validate any upgrade through the published package on the minimum supported consumer framework.

## Build and test environments

Use a supported LTS SDK and runtime for normal development, packaging, and CI. Add STS compatibility coverage separately where useful. A newer build SDK does not by itself require raising a published package's target framework. Treat tests on an end-of-support runtime as compatibility coverage, not as a recommendation to deploy that runtime.

Keep Blazor WebAssembly and DevServer package majors aligned with each consumer target framework. In a project tested with multiple framework overrides, preserve the conditional package references for each framework.

Private build tooling such as `Microsoft.SourceLink.GitHub` may update independently after checking build compatibility. Keep SourceLink private and in its own Renovate group so tooling upgrades do not pull public dependencies into the same major-version update.

## Renovate and lifecycle reviews

`.github/renovate.json` compares each Blazor WebAssembly, DevServer, and `System.Drawing.Common` update's raw declared `currentValue` major with its proposed `newVersion` major using `matchJsonata`, and disables updates that cross that boundary. This comparison does not depend on the resolved `currentVersion`, which NuGet resolution can move to a newer major when matching releases are deprecated or unlisted. Updates within the declared major remain enabled. Major migrations are manual decisions; after an intentional major upgrade, Renovate follows the newly selected major without a version-specific denylist. Existing references for a newer framework remain eligible for updates within their own major.

Review this policy when a new LTS release becomes available and six months before the adopted LTS release reaches end of support. Check minimum consumer frameworks, public dependency support, the build SDK, and runtime test coverage separately. Use Microsoft's current [support policy](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core) rather than assuming support dates from version numbers. If a selected dependency line no longer receives a required fix, review a compatible newer dependency, framework-specific references, or a documented minimum-framework change instead of retaining it indefinitely.
