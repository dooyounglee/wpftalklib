using OTILib.Models;
using OTILib.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OTILib.Handlers
{
    public class ClientRoomManager
    {
        private Dictionary<int, List<ClientHandler>> _roomHandlersDict = new();

        public ClientHandler? getClientHandler(int roomId, int usrNo)
        {
            List<ClientHandler> list = _roomHandlersDict[roomId];
            foreach (ClientHandler handler in list)
            {
                if (handler.UsrNo == usrNo)
                {
                    return handler;
                }
            }
            return null;
        }

        public bool IsConnect(ClientHandler clientHandler)
        {
            if (_roomHandlersDict.TryGetValue(0, out _))
            {

            }
            else
            {
                return false;
            }

            List<ClientHandler> list = _roomHandlersDict[0];
            foreach (ClientHandler handler in list)
            {
                if (handler.UsrNo == clientHandler.UsrNo)
                {
                    return true;
                }
            }
            return false;
        }
        public void Add(ClientHandler clientHandler)
        {
            int roomId = clientHandler.InitialData!.RoomId;

            if (_roomHandlersDict.TryGetValue(roomId, out _))
            {
                _roomHandlersDict[roomId].Add(clientHandler);
            }
            else
            {
                _roomHandlersDict[roomId] = new List<ClientHandler>() { clientHandler };
            }
        }

        public void Remove(ClientHandler clientHandler)
        {
            int roomId = clientHandler.InitialData!.RoomId;
            OtiLogger.log1(roomId);

            if (_roomHandlersDict.TryGetValue(roomId, out List<ClientHandler>? roomHandlers))
            {
                OtiLogger.log1(roomHandlers.Count);
                _roomHandlersDict[roomId] = roomHandlers.FindAll(handler => !handler.UsrNo.Equals(clientHandler.UsrNo));
            }
        }

        public void SendToMyRoom(ChatHub hub)
        {
            if (_roomHandlersDict.TryGetValue(hub.RoomId, out List<ClientHandler>? roomHandlers))
            {
                roomHandlers.ForEach(handler => handler.Send(hub));
            }
        }

        public Dictionary<int, List<ClientHandler>> RoomHandlersDict()
        {
            return _roomHandlersDict;
        }

        public string ClientStates()
        {
            var list = new Dictionary<int, ConnState>();
            foreach (var each in _roomHandlersDict[0])
            {
                list.Add(each.InitialData.UsrNo, each.ConnState);
            }
            return JsonSerializer.Serialize(list);
        }

        public void printDictionary()
        {
            foreach (var item in _roomHandlersDict)
            {
                item.Value.ForEach(handler => OtiLogger.log1(item.Key + ": " + handler.InitialData.UsrNo));
            }
        }
    }
}
