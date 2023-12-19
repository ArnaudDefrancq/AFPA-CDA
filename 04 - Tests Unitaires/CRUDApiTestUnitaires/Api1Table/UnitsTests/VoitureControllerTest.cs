using Api.Controllers;
using Api.Interfaces;
using Api.Models.Data;
using Api.Models.DTOs;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http.HttpResults;
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
			Assert.IsInstanceOf<ActionResult<VoituresDto>>(getVoiture);
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
			Assert.NotNull(getVoiture.Result as NotFoundResult);
		}
		[Test]
		public void GetAllVoitures_Test_Exist()
		{
			// Initialisation d'un nouvelle objet
			var voiture = new Voiture { IdVoiture = 1, Marque = "testMarque", Model = "testModel", Km = 999 };
			var voiture1 = new Voiture { IdVoiture = 2, Marque = "testMarque", Model = "testModel", Km = 999 };
			var voiture2 = new Voiture { IdVoiture = 3, Marque = "testMarque", Model = "testModel", Km = 999 };

			List<Voiture> voitureList = new List<Voiture>() { voiture, voiture1, voiture2 };

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
			Assert.IsNotNull(getVoiture);
			Assert.IsInstanceOf<ActionResult<IEnumerable<VoituresDto>>>(getVoiture);
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
			Assert.NotNull(getVoiture.Result as NotFoundResult);
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
			Assert.IsInstanceOf<ActionResult<VoituresDto>>(getVoiture);
		}
		[Test]
		public void CreateVoiture_Test_BadObject()
		{
			var voiture = new Voiture() { };

			// Initialisation du mock pour le service
			var voitureRepo = new Mock<IVoituresService>();
			voitureRepo.Setup(x => x.AddVoitures(It.IsAny<Voiture>())).Throws(new ArgumentNullException(nameof(voiture)));

			// Initialisation du mock pour le profile
			var mapper = new Mock<IMapper>();

			// Initialisation du contrôleur
			var controller = new VoituresController(voitureRepo.Object, mapper.Object);

			// Appel de la méthode du contrôleur que vous testez
			var getVoiture = controller.CreateVoiture(voiture);

			// Assertions et vérifications
			Assert.IsNull(getVoiture.Value);
			Assert.IsInstanceOf<BadRequestObjectResult>(getVoiture.Result); ;
		}
		[Test]
		public void UpdateVoiture_Test_GoodObject()
		{
			int goodId = 1;

			var voiture = new Voiture { IdVoiture = goodId, Marque = "testMarque", Model = "testModel", Km = 999 };

			var voitureDto = new VoituresDto { Marque = "testMarque", Model = "testModel", Km = 9 };

			// Initialisation du mock pour le service
			var voitureRepo = new Mock<IVoituresService>();
			voitureRepo.Setup(x => x.GetVoitureById(goodId))
					   .Returns(voiture);
			voitureRepo.Setup(x => x.UpdateVoiture(voiture));


			// Initialisation du mock pour le profile
			var mapper = new Mock<IMapper>();

			// Initialisation du contrôleur
			var controller = new VoituresController(voitureRepo.Object, mapper.Object);

			// Appel de la méthode du contrôleur que vous testez
			var getVoiture = controller.UpdateVoiture(goodId, voitureDto);

			// Assertions et vérifications
			Assert.IsNotNull(getVoiture);
			Assert.IsInstanceOf<NoContentResult>(getVoiture);
		}
		[Test]
		public void UpdateVoiture_Test_BadObject()
		{
			int badId = 999;

			var voiture = new Voiture { IdVoiture = 1, Marque = "testMarque", Model = "testModel", Km = 999 };

			var voitureDto = new VoituresDto { Marque = "testMarque", Model = "testModel", Km = 9 };

			// Initialisation du mock pour le service
			var voitureRepo = new Mock<IVoituresService>();
			voitureRepo.Setup(x => x.GetVoitureById(badId))
					   .Returns((Voiture)null); // Simuler le cas où la voiture n'existe pas
			voitureRepo.Setup(x => x.UpdateVoiture(It.IsAny<Voiture>()));

			// Initialisation du mock pour le profile
			var mapper = new Mock<IMapper>();

			// Initialisation du contrôleur
			var controller = new VoituresController(voitureRepo.Object, mapper.Object);

			// Appel de la méthode du contrôleur que vous testez
			var getVoiture = controller.UpdateVoiture(badId, voitureDto);

			// Assertions et vérifications
			Assert.IsNotNull(getVoiture);
			Assert.IsInstanceOf<NotFoundResult>(getVoiture);
		}

	}
}