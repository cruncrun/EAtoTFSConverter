﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EAtoTFSConverter
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="EATFSConverter")]
	public partial class DataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertEAScenario(EAScenario instance);
    partial void UpdateEAScenario(EAScenario instance);
    partial void DeleteEAScenario(EAScenario instance);
    partial void InsertStep(Step instance);
    partial void UpdateStep(Step instance);
    partial void DeleteStep(Step instance);
    partial void InsertUseCase(UseCase instance);
    partial void UpdateUseCase(UseCase instance);
    partial void DeleteUseCase(UseCase instance);
    #endregion
		
		public DataClassesDataContext() : 
				base(global::EAtoTFSConverter.Properties.Settings.Default.EATFSConverterConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<EAScenario> EAScenarios
		{
			get
			{
				return this.GetTable<EAScenario>();
			}
		}
		
		public System.Data.Linq.Table<Step> Steps
		{
			get
			{
				return this.GetTable<Step>();
			}
		}
		
		public System.Data.Linq.Table<UseCase> UseCases
		{
			get
			{
				return this.GetTable<UseCase>();
			}
		}
		
		public System.Data.Linq.Table<active_EAscenario> active_EAscenarios
		{
			get
			{
				return this.GetTable<active_EAscenario>();
			}
		}
		
		public System.Data.Linq.Table<active_Step> active_Steps
		{
			get
			{
				return this.GetTable<active_Step>();
			}
		}
		
		public System.Data.Linq.Table<TestPlan> TestPlans
		{
			get
			{
				return this.GetTable<TestPlan>();
			}
		}
		
		public System.Data.Linq.Table<Project> Projects
		{
			get
			{
				return this.GetTable<Project>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.EAScenario")]
	public partial class EAScenario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _XmiId;
		
		private string _SubjectId;
		
		private System.Guid _ProjectId;
		
		private string _Name;
		
		private string _Type;
		
		private string _Description;
		
		private System.Nullable<System.DateTime> _Timestamp;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnXmiIdChanging(string value);
    partial void OnXmiIdChanged();
    partial void OnSubjectIdChanging(string value);
    partial void OnSubjectIdChanged();
    partial void OnProjectIdChanging(System.Guid value);
    partial void OnProjectIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnTypeChanging(string value);
    partial void OnTypeChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnTimestampChanging(System.Nullable<System.DateTime> value);
    partial void OnTimestampChanged();
    #endregion
		
		public EAScenario()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_XmiId", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string XmiId
		{
			get
			{
				return this._XmiId;
			}
			set
			{
				if ((this._XmiId != value))
				{
					this.OnXmiIdChanging(value);
					this.SendPropertyChanging();
					this._XmiId = value;
					this.SendPropertyChanged("XmiId");
					this.OnXmiIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubjectId", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string SubjectId
		{
			get
			{
				return this._SubjectId;
			}
			set
			{
				if ((this._SubjectId != value))
				{
					this.OnSubjectIdChanging(value);
					this.SendPropertyChanging();
					this._SubjectId = value;
					this.SendPropertyChanged("SubjectId");
					this.OnSubjectIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProjectId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ProjectId
		{
			get
			{
				return this._ProjectId;
			}
			set
			{
				if ((this._ProjectId != value))
				{
					this.OnProjectIdChanging(value);
					this.SendPropertyChanging();
					this._ProjectId = value;
					this.SendPropertyChanged("ProjectId");
					this.OnProjectIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(MAX)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Timestamp", DbType="DateTime")]
		public System.Nullable<System.DateTime> Timestamp
		{
			get
			{
				return this._Timestamp;
			}
			set
			{
				if ((this._Timestamp != value))
				{
					this.OnTimestampChanging(value);
					this.SendPropertyChanging();
					this._Timestamp = value;
					this.SendPropertyChanged("Timestamp");
					this.OnTimestampChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Step")]
	public partial class Step : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private System.Guid _Guid;
		
		private System.Guid _EAScenarioId;
		
		private string _SubjectId;
		
		private string _Name;
		
		private int _Level;
		
		private string _Result;
		
		private System.Nullable<System.DateTime> _Timestamp;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnGuidChanging(System.Guid value);
    partial void OnGuidChanged();
    partial void OnEAScenarioIdChanging(System.Guid value);
    partial void OnEAScenarioIdChanged();
    partial void OnSubjectIdChanging(string value);
    partial void OnSubjectIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnLevelChanging(int value);
    partial void OnLevelChanged();
    partial void OnResultChanging(string value);
    partial void OnResultChanged();
    partial void OnTimestampChanging(System.Nullable<System.DateTime> value);
    partial void OnTimestampChanged();
    #endregion
		
		public Step()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Guid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid Guid
		{
			get
			{
				return this._Guid;
			}
			set
			{
				if ((this._Guid != value))
				{
					this.OnGuidChanging(value);
					this.SendPropertyChanging();
					this._Guid = value;
					this.SendPropertyChanged("Guid");
					this.OnGuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EAScenarioId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid EAScenarioId
		{
			get
			{
				return this._EAScenarioId;
			}
			set
			{
				if ((this._EAScenarioId != value))
				{
					this.OnEAScenarioIdChanging(value);
					this.SendPropertyChanging();
					this._EAScenarioId = value;
					this.SendPropertyChanged("EAScenarioId");
					this.OnEAScenarioIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubjectId", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string SubjectId
		{
			get
			{
				return this._SubjectId;
			}
			set
			{
				if ((this._SubjectId != value))
				{
					this.OnSubjectIdChanging(value);
					this.SendPropertyChanging();
					this._SubjectId = value;
					this.SendPropertyChanged("SubjectId");
					this.OnSubjectIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Level]", Storage="_Level", DbType="Int NOT NULL")]
		public int Level
		{
			get
			{
				return this._Level;
			}
			set
			{
				if ((this._Level != value))
				{
					this.OnLevelChanging(value);
					this.SendPropertyChanging();
					this._Level = value;
					this.SendPropertyChanged("Level");
					this.OnLevelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Result", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Result
		{
			get
			{
				return this._Result;
			}
			set
			{
				if ((this._Result != value))
				{
					this.OnResultChanging(value);
					this.SendPropertyChanging();
					this._Result = value;
					this.SendPropertyChanged("Result");
					this.OnResultChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Timestamp", DbType="DateTime")]
		public System.Nullable<System.DateTime> Timestamp
		{
			get
			{
				return this._Timestamp;
			}
			set
			{
				if ((this._Timestamp != value))
				{
					this.OnTimestampChanging(value);
					this.SendPropertyChanging();
					this._Timestamp = value;
					this.SendPropertyChanged("Timestamp");
					this.OnTimestampChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UseCase")]
	public partial class UseCase : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private System.Guid _EAScenarioId;
		
		private System.Guid _Guid;
		
		private string _SubjectId;
		
		private string _Name;
		
		private System.Nullable<System.DateTime> _Timestamp;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnEAScenarioIdChanging(System.Guid value);
    partial void OnEAScenarioIdChanged();
    partial void OnGuidChanging(System.Guid value);
    partial void OnGuidChanged();
    partial void OnSubjectIdChanging(string value);
    partial void OnSubjectIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnTimestampChanging(System.Nullable<System.DateTime> value);
    partial void OnTimestampChanged();
    #endregion
		
		public UseCase()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EAScenarioId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid EAScenarioId
		{
			get
			{
				return this._EAScenarioId;
			}
			set
			{
				if ((this._EAScenarioId != value))
				{
					this.OnEAScenarioIdChanging(value);
					this.SendPropertyChanging();
					this._EAScenarioId = value;
					this.SendPropertyChanged("EAScenarioId");
					this.OnEAScenarioIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Guid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid Guid
		{
			get
			{
				return this._Guid;
			}
			set
			{
				if ((this._Guid != value))
				{
					this.OnGuidChanging(value);
					this.SendPropertyChanging();
					this._Guid = value;
					this.SendPropertyChanged("Guid");
					this.OnGuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubjectId", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string SubjectId
		{
			get
			{
				return this._SubjectId;
			}
			set
			{
				if ((this._SubjectId != value))
				{
					this.OnSubjectIdChanging(value);
					this.SendPropertyChanging();
					this._SubjectId = value;
					this.SendPropertyChanged("SubjectId");
					this.OnSubjectIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Timestamp", DbType="DateTime")]
		public System.Nullable<System.DateTime> Timestamp
		{
			get
			{
				return this._Timestamp;
			}
			set
			{
				if ((this._Timestamp != value))
				{
					this.OnTimestampChanging(value);
					this.SendPropertyChanging();
					this._Timestamp = value;
					this.SendPropertyChanged("Timestamp");
					this.OnTimestampChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.active_EAscenarios")]
	public partial class active_EAscenario
	{
		
		private System.Guid _Id;
		
		private string _Name;
		
		private string _Type;
		
		private string _Description;
		
		private string _SubjectId;
		
		private System.Guid _ProjectId;
		
		private System.Nullable<System.DateTime> _Timestamp;
		
		public active_EAscenario()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this._Type = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(MAX)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubjectId", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string SubjectId
		{
			get
			{
				return this._SubjectId;
			}
			set
			{
				if ((this._SubjectId != value))
				{
					this._SubjectId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProjectId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ProjectId
		{
			get
			{
				return this._ProjectId;
			}
			set
			{
				if ((this._ProjectId != value))
				{
					this._ProjectId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Timestamp", DbType="DateTime")]
		public System.Nullable<System.DateTime> Timestamp
		{
			get
			{
				return this._Timestamp;
			}
			set
			{
				if ((this._Timestamp != value))
				{
					this._Timestamp = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.active_Steps")]
	public partial class active_Step
	{
		
		private System.Guid _Id;
		
		private System.Guid _Guid;
		
		private System.Guid _EAScenarioId;
		
		private string _SubjectId;
		
		private string _Name;
		
		private int _Level;
		
		private string _Result;
		
		private System.Nullable<System.DateTime> _Timestamp;
		
		public active_Step()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Guid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid Guid
		{
			get
			{
				return this._Guid;
			}
			set
			{
				if ((this._Guid != value))
				{
					this._Guid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EAScenarioId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid EAScenarioId
		{
			get
			{
				return this._EAScenarioId;
			}
			set
			{
				if ((this._EAScenarioId != value))
				{
					this._EAScenarioId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubjectId", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string SubjectId
		{
			get
			{
				return this._SubjectId;
			}
			set
			{
				if ((this._SubjectId != value))
				{
					this._SubjectId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Level]", Storage="_Level", DbType="Int NOT NULL")]
		public int Level
		{
			get
			{
				return this._Level;
			}
			set
			{
				if ((this._Level != value))
				{
					this._Level = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Result", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Result
		{
			get
			{
				return this._Result;
			}
			set
			{
				if ((this._Result != value))
				{
					this._Result = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Timestamp", DbType="DateTime")]
		public System.Nullable<System.DateTime> Timestamp
		{
			get
			{
				return this._Timestamp;
			}
			set
			{
				if ((this._Timestamp != value))
				{
					this._Timestamp = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TestPlan")]
	public partial class TestPlan
	{
		
		private System.Guid _Id;
		
		private System.Guid _ProjectId;
		
		private int _WorkItemId;
		
		public TestPlan()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProjectId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ProjectId
		{
			get
			{
				return this._ProjectId;
			}
			set
			{
				if ((this._ProjectId != value))
				{
					this._ProjectId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WorkItemId", DbType="Int NOT NULL")]
		public int WorkItemId
		{
			get
			{
				return this._WorkItemId;
			}
			set
			{
				if ((this._WorkItemId != value))
				{
					this._WorkItemId = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Project")]
	public partial class Project
	{
		
		private System.Guid _Id;
		
		private string _Name;
		
		private string _DevOpsProject;
		
		private string _DevOpsOrganization;
		
		private string _Address;
		
		private string _AuthorizationToken;
		
		public Project()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DevOpsProject", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string DevOpsProject
		{
			get
			{
				return this._DevOpsProject;
			}
			set
			{
				if ((this._DevOpsProject != value))
				{
					this._DevOpsProject = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DevOpsOrganization", DbType="NVarChar(MAX)")]
		public string DevOpsOrganization
		{
			get
			{
				return this._DevOpsOrganization;
			}
			set
			{
				if ((this._DevOpsOrganization != value))
				{
					this._DevOpsOrganization = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(MAX)")]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this._Address = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuthorizationToken", DbType="NVarChar(MAX)")]
		public string AuthorizationToken
		{
			get
			{
				return this._AuthorizationToken;
			}
			set
			{
				if ((this._AuthorizationToken != value))
				{
					this._AuthorizationToken = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
