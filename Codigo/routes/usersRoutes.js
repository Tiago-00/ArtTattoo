var express = require('express');
var router = express.Router();
var uModel = require("../models/usersModel");



router.post('/login', async function (req, res, next) {
  let nome = req.body.nome;
  let password = req.body.password;
  let result = await uModel.login(nome, password);
  res.status(result.status).send(result);
 
});

router.post("/adduser", async function (req, res, next) {
  let user = req.body;
  console.log(user);
  let result = await uModel.AddUser(user);
  res.status(result.status).send(result);
});

router.get('/:id', async function (req, res, next) {
  let id = req.params.id;
  console.log("Sending user with id " + id);
  let result = await uModel.getUserById(id);
  res.status(result.status).send(result.result);
});

router.get("/images",async function (req, res, next) {
  let images = await uModel.AllPhotos();
  res.status(images.status).send(images.result);
});


module.exports = router;