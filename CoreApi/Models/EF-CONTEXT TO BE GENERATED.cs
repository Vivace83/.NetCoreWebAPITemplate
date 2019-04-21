using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Models
{
    public class EF_CONTEXT_TO_BE_GENERATED
    {
        //CURRENTLY INSTALLED NUGET PACKAGE ASSUMES MSSQL BACKEND
        //EF CONTEXT NEEDS TO BE GENERATED EITHER FROM CODE FIRST MIGRATIONS
        //OR FROM EXISTING DATABASE

        //TO BUILDING SCAFFOLDING USING EXISTING DB USE THE FOLLOWING PMC COMMAND
        //Scaffold-DbContext "Server=SERVER_NAME_OR_IP;Database=DATABASE_NAME;User ID=USERNAME_IF_NEEDED;Password=PASSWORD_IF_NEEDED;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables [TABLE_NAME_HERE],[TABLE_NAME_HERE] -force

    }
}
