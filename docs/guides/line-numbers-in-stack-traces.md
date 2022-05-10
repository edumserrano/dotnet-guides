# Line numbers in stack traces

## Motivation

I want to see line numbers in the stack trace of an exception. Line number information comes from the symbol file (PDB) and when the exception comes from a NuGet package you might not have the PDB available.

In my scenario I was consuming a NuGet package that had the PDB included but I still did NOT have the line numbers in the stack trace of the exception. My project was a .NET 6 project that consumed a .NET5 NuGet package.

## If the PDB is available in the NuGet package what is missing ?

The problem is related to what is explained in [Debug NuGet package with included symbols](debug-pdg-included-on-nuget.md). What is happening is that when the PDB is included in the NuGet package then by default a .NET app will not copy it to the output causing this issue.

## How to fix the problem ?

The same solution explained in [Debug NuGet package with included symbols](debug-pdg-included-on-nuget.md) will also solve this problem.

After all what we need is to make sure the PDBs are available when the app is running, which this fix will do.

Alternatively, if you have control of the NuGet package you could chose to embed the PDB into the DLL of the NuGet package. For more info read through the suggestion on this GitHub issue: [New project system doesn't copy PDBs from packages](https://github.com/dotnet/sdk/issues/1458).

## What about if I use a separate package for symbols (.snupkg) ?

I haven't tested this scenario. It might be the case that the workaround proposed is not necessary for this case.