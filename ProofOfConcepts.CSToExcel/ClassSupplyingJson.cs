using System;
using System.Runtime.InteropServices;

namespace ProofOfConcepts.CSToExcel;

[Guid(ClassSupplyingJsonGuids.ServerInterface)]
[ComVisible(true)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IClassSupplyingJson 
{  
    string Init(string filePath); 
} 

[Guid(ClassSupplyingJsonGuids.ServerClass)]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class ClassSupplyingJson : IClassSupplyingJson
{
    public ClassSupplyingJson()
    {

    }

    public string Init(string filePath)
    {
        string retVal = string.Empty;
        if(filePath == string.Empty)
            return retVal;   
    
        using (StreamReader r = new StreamReader(filePath))
            retVal = r.ReadToEnd();

        return retVal;
    }
    
}
