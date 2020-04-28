//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System.Linq;
using EditorDatabase.Enums;
using EditorDatabase.Serializable;
using EditorDatabase.Model;

namespace EditorDatabase.DataModel
{
	public partial class SatelliteBuild
	{
		partial void OnDataDeserialized(SatelliteBuildSerializable serializable, Database database);


		public SatelliteBuild(SatelliteBuildSerializable serializable, Database database)
		{
			Id = new ItemId<SatelliteBuild>(serializable.Id, serializable.FileName);
			Satellite = database.GetSatelliteId(serializable.SatelliteId);
			if (Satellite.IsNull)
			    throw new DatabaseException(this.GetType().Name + ".Satellite cannot be null");
			NotAvailableInGame = serializable.NotAvailableInGame;
			DifficultyClass = serializable.DifficultyClass;
			Components = serializable.Components?.Select(item => new InstalledComponent(item, database)).ToArray();

			OnDataDeserialized(serializable, database);
		}

		public void Save(SatelliteBuildSerializable serializable)
		{
			serializable.SatelliteId = Satellite.Value;
			serializable.NotAvailableInGame = NotAvailableInGame;
			serializable.DifficultyClass = DifficultyClass;
			if (Components == null || Components.Length == 0)
			    serializable.Components = null;
			else
			    serializable.Components = Components.Select(item => item.Serialize()).ToArray();
		}

		public readonly ItemId<SatelliteBuild> Id;

		public ItemId<Satellite> Satellite = ItemId<Satellite>.Empty;
		public bool NotAvailableInGame;
		public DifficultyClass DifficultyClass;
		public InstalledComponent[] Components;

		public static SatelliteBuild DefaultValue { get; private set; }
	}
}
