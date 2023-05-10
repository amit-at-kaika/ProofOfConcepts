# ProofOfConcepts
A test .NET 7 project to create a WebAPI with MySql.

## This includes:
- [x] Use of Pomelo to interact with a pre-existing MySQL database.
- [x] Addition of a standard controller, *ActorsController.cs*, to implement CRUD against a table, *Actor*.
- [x] Test library to add unit tests for the DbContext based on *xunit*.
- [x] Use of Secrets to run xUnit Tests for a Lib
- [x] Use of the Authentication and Authorization. 
- [x] Call a .NET 7 dll from an Excel VBA Macro 


## Note
- This is based on the ideas introduced in https://github.com/markjprice/cs11dotn
- The videos of https://github.com/mohamadlawand087 
- The connection string is hardcoded in the *appsettings.Development.json*
- The tlb is created by midl.exe
```
midl.exe ClassSupplyingJson.idl /tlb ClassSupplyingJson.tlb /target NT60
```
- The dll is registered by regsvr32.exe 
```
regsvr32 ProofOfConcepts.CSToExcel.comhost.dll
```
