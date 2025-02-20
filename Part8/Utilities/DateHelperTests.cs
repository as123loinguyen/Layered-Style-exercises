using Xunit;
using Part8.Utilities;
using System;
using Microsoft.Extensions.Configuration.UserSecrets;

public class DateHelperTests
{
    [Fact]
    public void GetCurrentDate_ShouldReturnTodayDate()
    {
        var result = DateHelper.GetCurrentDate();

        Assert.Equal(DateTime.Today, result);
    }
}
