using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreApi.Helpers;
using CoreApi.Models;

namespace CoreApi.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString()
        {
            var sb = new StringBuilder();
            sb.Append(@"
						<html>
							<head>
							</head>
							<body>
								<div class='header'><h1>This is the generated PDF report!!!</h1></div>
								<table align='center'>
									<tr>
									</tr>");

            sb.Append(@"
								</table>
							</body>
						</html>");

            return sb.ToString();
        }

    }
}