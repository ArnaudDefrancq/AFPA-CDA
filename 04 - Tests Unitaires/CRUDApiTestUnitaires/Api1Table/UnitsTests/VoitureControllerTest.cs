using Api.Controllers;
using Api.Interfaces;
using Api.Models.Data;
using Api.Models.DTOs;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MySqlX.XDevAPI.Common;


namespace UnitsTests
{
	public class VoitureControllerTest
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void GetVoitureById_Test_IdExist()
		{
			// Initialisation d'un nouvelle objet
			int goodId = 1;
			var voiture = new Voiture { IdVoiture = goodId, Marque = "testMarque", Model = "testModel", Km = 999 };

			// Initialisation du mock pour le service
			var voitureRepo = new Mock<IVoituresService>();
			voitureRepo.Setup(x => x.GetVoitureById(It.IsAny<int>())).Returns(voiture);

			// Initialisation du mock pour le profile
			var mapper = new Mock<IMapper>();

			// Initialisation du contrôleur
			var controller = new VoituresController(voitureRepo.Object, mapper.Object);

			// Appel de la méthode du contrôleur que vous testez
			var getVoiture = controller.GetVoitureById(goodId);

			// Assertions et vérifications
			Assert.IsNotNull(getVoiture);
		}
		[Test]
		public void GetVoitureById_Test_IdNotExist()
		{
			// Initialisation d'un nouvelle objet
			int badId = 999;

			// Initialisation du mock pour le service
			var voitureRepo = new Mock<IVoituresService>();
			voitureRepo.Setup(x => x.GetVoitureById(badId)).Returns((Voiture)null);

			// Initialisation du mock pour le profile
			var mapper = new Mock<IMapper>();

			// Initialisation du contrôleur
			var controller = new VoituresController(voitureRepo.Object, mapper.Object);

			// Appel de la méthode du contrôleur que vous testez
			var getVoiture = controller.GetVoitureById(badId);

			// Assertions et vérifications
			Assert.IsNull(getVoiture.Value);
		}
		[Test]
		public void GetAllVoitures_Test_Exist()
		{
			// Initialisation d'un nouvelle objet
			var voiture = new Voiture { IdVoiture = 1, Marque = "testMarque", Model = "testModel", Km = 999 };
			var voiture1 = new Voiture { IdVoiture = 2, Marque = "testMarque", Model = "testModel", Km = 999 };
			var voiture2 = new Voiture { IdVoiture = 3, Marque = "testMarque", Model = "testModel", Km = 999 };

			IEnumerable<Voiture> voitureList = new List<Voiture>() { voiture, voiture1, voiture2 };

			// Initialisation du mock pour le service
			var voitureRepo = new Mock<IVoituresService>();
			voitureRepo.Setup(x => x.GetAllVoitures()).Returns(voitureList);

			// Initialisation du mock pour le profile
			var mapper = new Mock<IMapper>();

			// Initialisation du contrôleur
			var controller = new VoituresController(voitureRepo.Object, mapper.Object);

			// Appel de la méthode du contrôleur que vous testez
			var getVoiture = controller.GetAllVoitures();

			// Assertions et vérifications
			Assert.IsNotNull(getVoiture.Value);
		}
		[Test]
		public void GetAllVoitures_Test_NotExist()
		{
			// Initialisation du mock pour le service
			var voitureRepo = new Mock<IVoituresService>();
			voitureRepo.Setup(x => x.GetAllVoitures()).Returns((IEnumerable<Voiture>)null);

			// Initialisation du mock pour le profile
			var mapper = new Mock<IMapper>();

			// Initialisation du contrôleur
			var controller = new VoituresController(voitureRepo.Object, mapper.Object);

			// Appel de la méthode du contrôleur que vous testez
			var getVoiture = controller.GetAllVoitures();

			// Assertions et vérifications
			Assert.IsNull(getVoiture.Value);
		}
		[Test]
		public void CreateVoiture_Test_GoodObject()
		{
			var voiture = new Voiture { Marque = "testMarque", Model = "testModel", Km = 99 };

			// Initialisation du mock pour le service
			var voitureRepo = new Mock<IVoituresService>();
			voitureRepo.Setup(x => x.AddVoitures(voiture));

			// Initialisation du mock pour le profile
			var mapper = new Mock<IMapper>();

			// Initialisation du contrôleur
			var controller = new VoituresController(voitureRepo.Object, mapper.Object);

			// Appel de la méthode du contrôleur que vous testez
			var getVoiture = controller.CreateVoiture(voiture);

			// Assertions et vérifications
			Assert.IsNotNull(getVoiture);
		}
		[Test]
		public void CreateVoiture_Test_BadObject()
		{
			var voiture = new Voiture() { };

			// Initialisation du mock pour le service
			var voitureRepo = new Mock<IVoituresService>();
			voitureRepo.Setup(x => x.AddVoitures(voiture));

			// Initialisation du mock pour le profile
			var mapper = new Mock<IMapper>();

			// Initialisation du contrôleur
			var controller = new VoituresController(voitureRepo.Object, mapper.Object);

			// Appel de la méthode du contrôleur que vous testez
			var getVoiture = controller.CreateVoiture(voiture);

			// Assertions et vérifications
			Assert.IsNull(getVoiture.Value);
		}
	}
}