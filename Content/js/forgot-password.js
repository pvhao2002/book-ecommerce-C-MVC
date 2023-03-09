let modal = document.querySelector('#modal');
let bodyBackgroud = document.querySelector('.hidden-body-background');
let btn = document.getElementById("forget-password-button");

function toggle(event){

    event.preventDefault()
    modal.style.display = 'block';


}

btn.addEventListener('click',toggle);
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
//
