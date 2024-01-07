// Same as above but you can set the length. Must be between 8 and 128
// Will return a password which is 32 characters long
using PasswordGenerator;

var pwd = new Password(32);
var password = pwd.Next();

Console.WriteLine(password);