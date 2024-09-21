using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Plugin.Additional
{
    public class CSCommander : Akequ.Base.Room
    {
        private string command;
        public override void Init()
        {
            if (!netEvent.isClient)
            {
                Run();
            }
        }

        public void Run()
        {
            Invoke(() =>
            {
                StreamReader streamReader = new StreamReader("order.txt");
                command = streamReader.ReadLine();
                streamReader.Close();
                Command();
                StreamWriter streamWriter = new StreamWriter("order.txt");
                streamWriter.WriteLine("");
                streamWriter.Close();
                Run();
            }, 1);
        } 

        public void Command()
        {
            switch (command)
            {
                case "Test":
                    Debug.Log("Test");
                    break;
                case "GetPlayers":
                    Debug.Log("Players:" + GameObject.FindObjectsOfType<Player>().Length);
                    break;
                case "ShowPlayerList":
                    foreach(Player player in GameObject.FindObjectsOfType<Player>())
                    {
                        Debug.Log($"{player.accountName}:{player.accountUID}");
                    }
                    break;
            }
        }

    }
}

public class Info : Akequ.Plugins.PluginInfo
{
    public override string Name => "CSCommander";

    public override string Id => "where";

    public override string Version => "1";

    public override ushort BundleVersion => 114;

    public override string[] MustSpawnClasses => new string[] { };
    public Info() { }
}
