namespace OTILib.Models
{
  public class ConnectionDetails
  {
    public int UsrNo { get; set; }
    public string UsrId { get; set; } = string.Empty;
    public string UsrNm { get; set; } = string.Empty;
    public int RoomId { get; set; }
    public Dictionary<int, object> Data { get; set; } = new Dictionary<int, object>();
    public string Data1 { get; set; }
    public ConnState connState { get; set; }
    public byte[] Data2 { get; set; }
    public string inviter { get; set; }
    public string invitee { get; set; }

    public override string ToString()
    {
      return $"UsrNo: {UsrNo}, UsrId: {UsrId}, UsrNm: {UsrNm}, RoomId: {RoomId}";
    }
  }
}
