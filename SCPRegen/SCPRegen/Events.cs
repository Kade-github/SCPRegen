using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SCPRegen
{
    class Events : IEventHandlerWaitingForPlayers, IEventHandlerRoundEnd
    {
        private readonly SCPRegen plugin;

        static bool isStarted = false;
        public Events(SCPRegen plugin) => this.plugin = plugin;

        public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
        {
            isStarted = true;
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while (isStarted)
                {
                    List<Player> a = plugin.Server.GetPlayers();
                    foreach (Player s in a)
                    {
                        if (s.TeamRole.Team == Team.SCP)
                        {
                            s.AddHealth(plugin.GetConfigInt("scpr_regenerate_hp"));
                        }
                    }
                    Thread.Sleep(plugin.GetConfigInt("scpr_regenerate_timer"));
                }
            }).Start();
        }

        public void OnRoundEnd(RoundEndEvent ev) => isStarted = false;
    }
}
