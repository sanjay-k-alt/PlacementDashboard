
<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Companies.aspx.cs"
    Inherits="PlacementDashboard.Companies" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Company Placement Details</title>
    <link href="Content/Site.css" rel="stylesheet" />
</head>

<body>
<form id="form1" runat="server">

<div class="container">

    <h1>COMPANY PLACEMENT DETAILS</h1>

    <asp:GridView ID="gvCompanies"
        runat="server"
        AutoGenerateColumns="True"
        CssClass="data-grid"
        EmptyDataText="No placement records found."
        GridLines="Both">
    </asp:GridView>

    <p>
        <a href="Default.aspx">Back to Dashboard</a>
    </p>

</div>

</form>
</body>
</html>
