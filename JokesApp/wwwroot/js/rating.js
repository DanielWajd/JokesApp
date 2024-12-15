document.addEventListener("DOMContentLoaded", function () {
    const stars = document.querySelectorAll(".star-rating .star");
    const ratingInput = document.getElementById("RatingValue");

    stars.forEach(star => {
        star.addEventListener("click", function () {
            const rating = this.getAttribute("data-value");
            ratingInput.value = rating;

            stars.forEach(s => s.classList.remove("selected"));

            this.classList.add("selected");
            let previousSibling = this.previousElementSibling;
            while (previousSibling) {
                previousSibling.classList.add("selected");
                previousSibling = previousSibling.previousElementSibling;
            }
        });
    });
});