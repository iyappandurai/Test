<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="AuditSchedule.AddUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
    <script src="Scripts/Common.js" type="text/javascript"></script>
    <style>
#btnSave {
  background-color:#272130 ;
  border: none;
  color: white;
  padding: 7px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
}
#btnSchedule {
  background-color:#272130 ;
  border: none;
  color: white;
  padding: 7px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin-left: 45%;
  cursor: pointer;
}
#caption{
	position:relative;
	color:#FFF;
	font-size:25px;
	font-family:"Lucida Sans Unicode", "Lucida Grande", sans-serif;
}
table td
{
    width:70px;
    }
</style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%; height:80px; overflow-y:hidden; margin: 0 auto; background-color:#333">
    <p id="caption" style="height:44px; margin-top:20px;float:left; margin-left:38%; position:absolute">Auditor Schedule</p>
    </div>
    <br />
    <label runat="server" id="lblMsg"></label>
    <div style="width:679px;float:left;">
    <table style="margin-left: 35%;">
    <tr>
    <td>Auditor ID</td><td><asp:TextBox ID="txtId" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td>Auditor Name</td><td><asp:TextBox ID="txtUser" runat="server"></asp:TextBox></td>
    </tr>
    <tr align='center'>
    <td colspan='2'><asp:Button ID="btnSave" Text="Save" runat="server" 
            OnClientClick="ValidateAuditor();" onclick="btnSave_Click"/></td>
    </tr>
    
    </table>
    </div>
    <div style="height:200px;width:500px;overflow-y:scroll;border:thin solid #3a473f">
                                        <asp:GridView ID="grvAuditor" runat="server" Width="100%" AutoGenerateColumns="False"
                                             CellPadding="5" 
                                            EmptyDataText="No Records Found" >
                                            <Columns>
                                                <asp:BoundField DataField="Id" SortExpression="Id" HeaderText="Auditor Id">
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Name" SortExpression="Name" HeaderText="Auditor Name">
                                                </asp:BoundField>
                                               
                                               
                                            </Columns>
                                           
                                        </asp:GridView>
                                        </div>
                                        <br /><hr />
                                        <div id='divSchedule' style='height:300px;overflow-y:scroll'>
                                        
                                        </div>
                                        <br />
                                        <p>* Green color indicated audit scheduled</p>
                                       
                                         <button id="btnSchedule" onclick="return false;">Auto Schedule</button> 
    
    </form>
</body>
</html>
