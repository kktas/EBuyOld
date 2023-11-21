const buyAll = function () {
  let userId = Number(this.getAttribute("data-userId"));
  const cardEl = this.parentNode.parentNode.parentNode;
  let obj = {};
  obj["id"] = userId;
  let jsonObj = JSON.stringify(obj);

  $.ajax({
    type: "POST",
    url: "/Customer/BuyProducts/",
    data: jsonObj,
    contentType: "application/json",
    success: function (response) {
      window.location.replace(response.redirectUrl);
    },
  });
};

const removeFromCart = function () {
  let cartItemId = Number(this.getAttribute("data-itemId"));
  let obj = {};
  obj["id"] = cartItemId;

  const jsonObj = JSON.stringify(obj);

  $.ajax({
    type: "POST",
    url: "/Customer/RemoveFromCart",
    data: jsonObj,
    contentType: "application/json",
    success: function (response) {
      window.location.replace(response.redirectUrl);
    },
  });
};

const buyBtn = document.querySelector(".buybtn");
buyBtn.addEventListener("click", buyAll);

const removeBtns = document.querySelectorAll(".remove");

for (let i = 0; i < removeBtns.length; i++) {
  removeBtns[i].addEventListener("click", removeFromCart);
}
