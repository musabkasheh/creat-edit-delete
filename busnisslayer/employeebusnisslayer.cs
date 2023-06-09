﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace busnisslayer
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetAllEmployess()
        {
            //Reads the connection string from web.config file. The connection string name is DBCS
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //Create List of employees collection object which can store list of employees
            List<Employee> employees = new List<Employee>();
            //Establish the Connection to the database
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //Creating the command object by passing the stored procedure that is used to
                //retrieve all the employess from the tblEmployee table and the connection object
                //on which the stored procedure is going to execute
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                //Specify the command type as stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                //Open the connection
                con.Open();
                //Execute the command and stored the result in Data Reader as the method ExecuteReader
                //is going to return a Data Reader result set
                SqlDataReader rdr = cmd.ExecuteReader();
                //Read each employee from the SQL Data Reader and stored in employee object
                while (rdr.Read())
                {
                    //Creating the employee object to store employee information
                    Employee employee = new Employee();
                    employee.ID = Convert.ToInt32(rdr["Id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.City = rdr["City"].ToString();
                    employee.Salary = Convert.ToDecimal(rdr["Salary"]);
                    employee.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                    //Adding that employee into List of employees collection object
                    employees.Add(employee);
                }
            }
            //Return the list of employees that is stored in the list collection of employees
            return employees;
        }
        public void AddEmmployee(Employee employee)
        {
            //Creating the connection string
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //Establishing the connection to the database
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //Creating the command object by passing the stored procedure and connection object as argument
                //This stored procedure is used to store the employee in to the database
                SqlCommand cmd = new SqlCommand("spAddEmployee", con)
                {
                    //Specifying the command as stored procedure
                    CommandType = CommandType.StoredProcedure
                };
                //Creating SQL parameters because that stored procedure accept some input values
                SqlParameter paramName = new SqlParameter
                {
                    //Storing the parameter name of the stored procedure into the SQL parameter
                    //By using ParameterName property 
                    ParameterName = "@Name",
                    //storing the parameter value into sql parameter by using Value ptoperty
                    Value = employee.Name
                };
                //Adding that parameter into Command objects Parameter collection by using Add method
                //which will take the SQL parameter name as argument
                cmd.Parameters.Add(paramName);
                //Same for all other parameters (Gender, City, DateOfBirth )
                SqlParameter paramGender = new SqlParameter
                {
                    ParameterName = "@Gender",
                    Value = employee.Gender
                };
                cmd.Parameters.Add(paramGender);
                SqlParameter paramCity = new SqlParameter
                {
                    ParameterName = "@City",
                    Value = employee.City
                };
                cmd.Parameters.Add(paramCity);
                SqlParameter paramSalary = new SqlParameter
                {
                    ParameterName = "@Salary",
                    Value = employee.Salary
                };
                cmd.Parameters.Add(paramSalary);
                SqlParameter paramDateOfBirth = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = employee.DateOfBirth
                };
                cmd.Parameters.Add(paramDateOfBirth);
                //Open the connection and execute the command on ExecuteNonQuery method
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateEmmployee(Employee employee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = employee.ID;
                cmd.Parameters.Add(paramId);
                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);
                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);
                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                cmd.Parameters.Add(paramCity);
                SqlParameter paramSalary = new SqlParameter();
                paramSalary.ParameterName = "@Salary";
                paramSalary.Value = employee.Salary;
                cmd.Parameters.Add(paramSalary);
                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteEmployee(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = id;
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

