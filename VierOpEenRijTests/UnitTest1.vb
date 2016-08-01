Imports System.Drawing
Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports frmMain = VierOpEenRij.frmMain

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestSize500300()
        Dim frm = New frmMain
        Assert.AreEqual(frm.Size, New Size(500, 300))
    End Sub

    <TestMethod()> Public Sub TestRightWidthHeight()
        ' Assert.Equals(frmMain.BOARD_WIDTH, 
    End Sub

End Class