var pg = require('pg')

const connectionString = "postgres://bglfjbwdezzvzq:8d29f2a91ceebad0411442a932e677b29e3518ae104c7cedaa2e7cafb02fa4d9@ec2-52-48-159-67.eu-west-1.compute.amazonaws.com:5432/d4gq244te44gjk"
const Pool = pg.Pool
const pool = new Pool({
    connectionString,
    max: 10
	,
    ssl: {
        require: true, 
        rejectUnauthorized: false
    }
})
 
module.exports = pool