
<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="PlacementDashboard.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Placement Dashboard</title>
    <link href="Content/Site.css" rel="stylesheet" />
</head>

<body>
<form id="form1" runat="server">

<div class="container">

    <h1>PLACEMENT DASHBOARD</h1>

    <h2>Placement Summary</h2>

    <table class="summary">

        <tr>
            <th>Details</th>
            <th>Value</th>
        </tr>

        <tr>
            <td>Total Students</td>
            <td><asp:Label ID="lblTotal" runat="server" /></td>
        </tr>

        <tr>
            <td>Placed Students</td>
            <td><asp:Label ID="lblPlaced" runat="server" /></td>
        </tr>

        <tr>
            <td>Not Placed Students</td>
            <td><asp:Label ID="lblNotPlaced" runat="server" /></td>
        </tr>

        <tr>
            <td>Placement Percentage</td>
            <td><asp:Label ID="lblPercentage" runat="server" /></td>
        </tr>

        <tr>
            <td>Highest Package</td>
            <td><asp:Label ID="lblHighestPackage" runat="server" /></td>
        </tr>

    </table>

    <h2>Student Placement Details</h2>

    <asp:GridView ID="gvPlacements"
        runat="server"
        AutoGenerateColumns="False"
        CssClass="data-grid"
        EmptyDataText="No student records found."
        GridLines="Both">

        <Columns>

            <asp:BoundField
                DataField="EnrollmentNo"
                HeaderText="Enrollment No." />

            <asp:BoundField
                DataField="StudentName"
                HeaderText="Student Name" />

            <asp:BoundField
                DataField="Department"
                HeaderText="Department" />

            <asp:BoundField
                DataField="CompanyName"
                HeaderText="Company" />

            <asp:BoundField
                DataField="PackageLPA"
                HeaderText="Package (LPA)"
                DataFormatString="{0:F2}" />

        </Columns>

    </asp:GridView>

    <p>
        <a href="Companies.aspx">View Companies</a>
    </p>

</div>

</form>
</body>
</html>
