using System;
using CeVIO.Talk.RemoteService2; //参照登録した dll

namespace MyConsoleApp
{
    public class UseLocaldll
    {
        public void SomeMethod()
        {
            // CeVIO.Talk.RemoteService2.dll にて定義されたクラスを使用する
            ServiceControl2.StartHost(false);
        }
    }
}
