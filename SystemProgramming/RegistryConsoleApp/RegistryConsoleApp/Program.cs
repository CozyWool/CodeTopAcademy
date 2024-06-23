using Microsoft.Win32;

#pragma warning disable CA1416

string user = Registry.CurrentUser.Name;
string sKey = "GetSetValue";
var sKeyName = $"{user}\\{sKey}";

// Registry.SetValue(sKeyName, "", 0x1234);
// Registry.SetValue(sKeyName, "GSVQWord", 0x123456778Abc, RegistryValueKind.QWord);
// Registry.SetValue(sKeyName, "GSVString", "Пример строки :)");
// Registry.SetValue(sKeyName, "GSVArray", new[] {"значение 1", "значение 2", "значение 3"});
// Registry.CurrentUser.DeleteSubKey(sKey);

#pragma warning restore CA1416