const navBar = document.getElementById("nav-bar");


window.addEventListener("scroll", () => {

    if (window.scrollY > 60) {

        navBar.style.width = "70%";
        navBar.style.borderRadius = "0";
        navBar.style.borderBottom = "solid 0.8px #a8a5a5";
    }
    else {
        navBar.style.width = "80%";
        navBar.style.transition = "500ms";
        navBar.style.borderRadius = "20px";
    }
   
   
});