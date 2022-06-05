window.onload = async function(){

    try {
        let imagens = await $.ajax({
            url: '/api/users/images',
            method: 'get',
            dataType: 'json'
        });
    
        createImagesHTML(imagens);
    } catch (err) {
        console.log(err);
        alert(err.responseText);
    }
   
async function createImagesHTML(imagens) {
            let html = "";

            for ( image of imagens) {
               
                html += `<section class=flip-card>
                            <section class="flip-card-inner">
                                <section class="flip-card-front">
                                    <h1> ${image.image_nome}</h1><br>
                                    <img class="image" src="${image.image_url}">
                                </section>
                            </section>
                        </section>`
                      
            }
            document.getElementById("main").innerHTML = html;
        }
}
