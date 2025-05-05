using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTILib.Models
{
  public enum ChatState
  {
    None, Initial, Connect, Disconnect, ConnectFail,
    StateChange, Invite, Leave,
    File, Image,
    ChatReload
  }
}
