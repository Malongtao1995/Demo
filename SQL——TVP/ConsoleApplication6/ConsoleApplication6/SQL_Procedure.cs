using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class SQL_Procedure
    {
    //首先建立一张表 Product 字段ID和Name
        #region 查询——存储过程
        /****** Object:  StoredProcedure [dbo].[procGetProductsByProductIDsTVP]******/
        //SET ANSI_NULLS ON
        //GO
        //SET QUOTED_IDENTIFIER ON
        //GO

        //IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[procGetProductsByProductIDsTVP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
        //    DROP PROCEDURE [dbo].[procGetProductsByProductIDsTVP]
        //GO

        //Create PROCEDURE [dbo].[procGetProductsByProductIDsTVP]
        //(
        //    @ProductIDsTVP ProductIDsTVP READONLY
        //)
        //AS

        //SELECT p.ID, p.Name

        //FROM Product as p
        //INNER JOIN @ProductIDsTVP as t on p.ID = t.ID
        //    }
        #endregion
        #region 查询——TVP语句
//        IF NOT EXISTS(  SELECT * FROM sys.types WHERE name = 'ProductIDsTVP')
//    CREATE TYPE [dbo].[ProductIDsTVP] AS TABLE
//    (
//        [ID] INT
//    )
//GO 
        #endregion
        #region 删除——存储过程
//        /****** Object:  StoredProcedure [dbo].[procDeleteProductsByIDsByProductIDsTVP]******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
 
//IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[procDeleteProductsByProductIDsTVP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
//    DROP PROCEDURE [dbo].[procDeleteProductsByProductIDsTVP]
//GO
 
//Create PROCEDURE [dbo].[procDeleteProductsByProductIDsTVP]
//(
//    @ProductIDsTVP ProductIDsTVP READONLY
//)
//AS
             
//DELETE p FROM Product AS p
//INNER JOIN @ProductIDsTVP AS t on p.ID = t.ID
        #endregion
        #region 增加——存储过程
//        /****** Object:  StoredProcedure [dbo].[procInsertProductsByProductTVP]******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
 
//IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[procInsertProductsByProductTVP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
//    DROP PROCEDURE [dbo].[procInsertProductsByProductTVP]
//GO
 
//Create PROCEDURE [dbo].[procInsertProductsByProductTVP]
//(
//    @ProductTVP ProductTVP READONLY
//)
//AS
             
//INSERT INTO Product (ID, Name)
//SELECT
//    t.ID,
//    t.Name
//FROM @ProductTVP AS t
 
//GO
        #endregion//TVP语句需要改成更新的TVP语句
        #region 更新——存储过程
        /****** Object:  StoredProcedure [dbo].[procUpdateProductsByIDs]******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
 
//IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[procUpdateProductsByProductTVP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
//    DROP PROCEDURE [dbo].[procUpdateProductsByProductTVP]
//GO
 
//Create PROCEDURE [dbo].[procUpdateProductsByProductTVP]
//(
//    @ProductTVP ProductTVP READONLY
//)
//AS
             
//Update p
//SET
//    p.ID = t.ID,
//    p.Name = t.Name
//FROM product AS p
//INNER JOIN @ProductTVP AS t on p.ID = t.ID
 
//GO
        #endregion
        #region 更新——TVP语句
//        IF NOT EXISTS(  SELECT * FROM sys.types WHERE name = 'ProductTVP')
 
//    CREATE TYPE [dbo].[ProductTVP] AS TABLE(
//        [ID] [int] NULL,
//        [Name] NVARCHAR(100)
//    )
 
//GO
        #endregion
    }
}
