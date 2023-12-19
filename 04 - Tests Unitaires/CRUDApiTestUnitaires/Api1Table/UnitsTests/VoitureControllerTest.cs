using Api.Controllers;
using Api.Interfaces;
using Api.Models.Data;
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
	}
}