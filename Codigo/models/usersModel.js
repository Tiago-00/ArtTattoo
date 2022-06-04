var pool = require("./connection");

module.exports.login = async function (nome, password) {
    console.log(nome);
    console.log(password);
    try {
        let sql = "Select * from utilizador where use_nome = $1 and use_pass = $2 ";
        let result = await pool.query(sql, [nome,password]);
        if (result.rows.length >0 )
        return {
                status: 200,
                result: result.rows[0]
            };
    
        else  return {
            status: 400,
            result: {
                msg: "Nome ou password incorreta"
            }
        };
        
    } catch (err) {
        console.log(err);

        return {
            status: 500,
            result: err
        };
    }
}


module.exports.AddUser = async function (user) {
    try {
       
        let sql1 = "Select use_nome,use_email,use_pass "+
        "from utilizador "+
        "where use_nome = $1 and use_email = $2 and use_pass = $3 ";
       let result1 = await pool.query(sql1, [user.use_nome,user.use_email,user.use_pass]);
   
       if (result1.rows.length > 0 || (user.use_nome == '' || user.use_email == '' || user.use_pass== '')) {
           return {
               status: 500,
               alert: "Preencha o campo!",
           };        
       }
       
       let sql = "Insert into utilizador(use_nome,use_email,use_pass) values($1,$2,$3)";
           result1 = await pool.query(sql, [user.use_nome,user.use_email,user.use_pass]);
           let utilizador = result1.rows;        
        return {
            status: 200,
            result: utilizador
        };
        
    } catch (err) {
        console.log(err);
        return {
            status: 500,
            result: err
        };
    }
}

module.exports.getUserById = async function (id) {
    try {
        let sql = "Select * from utilizador where id_u = $1";
        let result = await pool.query(sql, [id]);
        if (result.rows.length > 0)
            return {
                status: 200,
                result: result.rows[0]
            };
        else return {
            status: 404,
            result: {
                msg: "Utilizador não encontrado"
            }
        };
    } catch (err) {
        console.log(err);
        return {
            status: 500,
            result: err
        };
    }
}


module.exports.AllPhotos = async function (){
    try{
        let sql = "Select  image_nome , image_url "+
          "from imagens  ";
        let result = await pool.query(sql);
        let photos = result.rows;
        return {
            status: 200,
            result: photos
        }

    } catch (err) {
        console.log(err);
        return {
            status: 500,
            result: err
        };
    }
    
}
