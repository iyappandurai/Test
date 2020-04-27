
function ValidateAuditor() {
    var userName = document.getElementById("txtUser").value;
    var userId = document.getElementById("txtId").value;
    if (userName == "" || userId == "") {
        alert("Auditor ID and Auditor name should not empty!!!")
        return false;
    }
}

$(document).ready(function () {
    $("#btnSchedule").click(function () {
        AutoSchedule();
    });
    bindTable();
});



function bindTable() {
    var container = $('#divSchedule'),
  table = $('<table>');
    table.attr('id', 'tblSchedule1');
    table.attr('border', '1');
    table.attr('cellpadding', '10');  
    table.attr('align', 'center');
    var tr = $('<tr>');
    tr.append('<td> Weeks / Auditors Name</td>');
    ////12 weeks
    for(var i=0;i<12;i++){
    tr.append('<td> Week' + (i+1) + '</td>');
    }
     table.append(tr);
     container.append(table);
     $.ajax({
         type: 'POST',
         url: 'AddUser.aspx/GetData',
         data: '{ }',
         contentType: "application/json; charset=utf-8",
         dataType: 'json',
         success: function (res) {
             table = $('<table>');
             table.attr('id', 'tblSchedule');
             table.attr('border', '1');
             table.attr('cellpadding', '10');
             table.attr('align', 'center');
             var objdata = $.parseJSON(res.d);
             if(objdata!=null){
             $.each(objdata.Table1, function (index, item) {
                 if (typeof (this[1]) != 'undefined') {
                     var tr = $('<tr>');

                     tr.append('<td>' + this[1] + '</td>');
                     for (var i = 0; i < 12; i++) {
                         tr.append('<td id=' + 'td~' + i + '> </td>');
                     }
                     table.append(tr);

                 }
             });
             container.append(table);
             }
         }


     });
 }

 function AutoSchedule() {
     var noofweeks = 12;
     var noOfAuditorPerWeek = 7;
     var TotalAuditor=92;
     var rowCount = $('#tblSchedule tr').length;
     ////Company has 92 auditor
     if ((rowCount) < TotalAuditor) {
         alert("Company should have 92 auditors");
         return;
     }
     $('#tblSchedule > tbody  > tr').each(function (index, tr) {
     
         var k = parseInt(index / 7);
         $(this).find('td:eq(' + (k+1) + ')').css("background-color", "green");
//         $.each(obj.Table1, function (index, item) {
//             if (typeof (this[1]) != 'undefined') {
//                 if (this[1] == $(tr).find('td:eq(0)').text()) {
//                     this[2] = $(tr).find('td:eq(' + (k+1) + ')').attr('id');//'Week' + k;
//                     
//                 }
//             }
//         });
         
 });


}
