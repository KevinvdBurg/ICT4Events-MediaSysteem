﻿using Oracle.DataAccess.Client;
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Database
{
    protected OracleConnection connection = new OracleConnection();
    protected string connectionString = "DATA SOURCE=fhictora01.fhict.local:1521/fhictora;PASSWORD=XAWdDJtZWV;USER ID=dbi314159";
    

	public Database()
	{

	}

	public void Connect()
	{
        try
        {
            connection = new OracleConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
        }
        catch
        {
            connection.Close();
        }
	}

	public void DisConnect()
	{
        connection.Close();
	}

    

}

