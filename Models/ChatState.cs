using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTILib.Models
{
  public enum ChatState
  {
    None, Initial, Connect, Disconnect, ConnectFail, // -> #0: 로그인, -> #n: 방 접속
    StateChange, Profile, // #0 -> #0
    Create, // #n+1 -> #0
    Chat, File, Image, Invite, Leave, // #n -> #n,#0

    ChatReload, ProfileReload,
    }
}
