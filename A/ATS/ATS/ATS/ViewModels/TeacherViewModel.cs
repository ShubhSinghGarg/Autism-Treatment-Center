﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATS.Models;
using ATS.Database;

namespace ATS.ViewModels
{
    public class TeacherViewModel : BaseViewModel
    {
        public TeacherModel _teacher;

        public TeacherModel Teacher 
        { 
            get; set; 
        }

        public ObservableCollection<PatientModel> _patients;

        public ObservableCollection<PatientModel> Patients
        {
            get { return _patients; }
            set { _patients = value; OnPropertyChanged(); }
        }

        public TeacherViewModel()
        {
           Initialize();
        }

        private async Task Initialize()
        {
            //  Database communication object to interact with our database
            DatabaseCommunication database = new DatabaseCommunication();

            Patients = await database.getGenericModelBatch<TeacherPatientModel, PatientModel>(2);
        }
    }
}
