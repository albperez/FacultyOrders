﻿<%@ Page Language="C#" MasterPageFile="~/FacultyOrders.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="FacultyOrders._default" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="Body">
    <h3>UCF Order Form</h3>

    <div>
        <a href="Accounting.aspx">Accounting</a>
    </div>

        <div>
        
               Name: <asp:TextBox ID= "txtName" runat = "server"></asp:TextBox>
               <br />
               <br />
        </div>

        <div>
        
               Email: <asp:TextBox ID= "txtEmail" runat = "server"></asp:TextBox>
               <br />
               <br />
        </div>

        <div>
               Account Number: <asp:TextBox ID="txtAccountNumber" runat="server"></asp:TextBox>
               <br />
               <br />
        </div>

        <div>
                Urgent Order: <asp:CheckBox ID="chkUrgent" runat="server" />
                <br />
                <br />
        </div>

        <div>
                Order contains Laptops/Computers? <asp:CheckBox ID="chkComp" runat="server" />
                <br />
                <br />
       </div>
                Vendor: <asp:TextBox ID="txtVendor" runat ="server"></asp:TextBox>
                <br />
                <br />
       <div>
                Item Description:<br />
                <asp:TextBox ID="txtItemDesc" TextMode="MultiLine" Rows="10" Width="400px" runat="server"></asp:TextBox>
                <br />
                <br />
       </div>
       <div>
                Total Order Amount: $<asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                <br />
                <br />
       </div>

       <div>
                <asp:FileUpload runat="server"/>
       </div>


       <div>
           <asp:Button ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" runat="server"/>
       </div>

        <div>
           <asp:Label ID="lblStatus" runat="server"/>
       </div>


    <asp:RegularExpressionValidator ID="revNumber" 
        ControlToValidate="txtAmount"
        ValidationExpression="^\d+(\.\d\d)?$"
        ErrorMessage="Please enter only numbers like 100 or 100.00" 
        runat="server"></asp:RegularExpressionValidator>

    <asp:RegularExpressionValidator ID="RegExEmailValid"
        ControlToValidate = "txtEmail"
        ValidationExpression = "\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        ErrorMessage = "Invalid Email Format"
        runat = "server"></asp:RegularExpressionValidator>
        <br />
    <asp:RegularExpressionValidator ID="RegExAccountValid"
       ControlToValidate="txtAccountNumber"
       ValidationExpression="\d+"
       ErrorMessage = "Please enter a valid Account Number"
       runat = "server"></asp:RegularExpressionValidator>

</asp:Content>