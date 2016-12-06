
      $(document).ready(function () {
          $('.grid-data').DataTable();
          $('.jqte-test').jqte();
      });   
function initModal() {
    $("#myModal").attr("modal-title", "Delete Item");
}

function addDeleteUrl(x) {
    var linkId = $(x).attr("link-id");
    var deleteUrl = "/Link/DeleteLink/";
    $("#deleteForm").attr("action", deleteUrl + linkId);
}
//Delete News Modal
function initModalNews() {
    $("#myModalNews").attr("modal-title", "Delete News");
}

function addDeleteUrlNews(x) {
    var newsId = $(x).attr("news-id");
    var deleteUrl = "/News/DeleteNews/";
    $("#deleteForm").attr("action", deleteUrl + newsId);
}
//Delete Benefit Modal
function initModalBenefit() {
    $("#myModalBenefit").attr("modal-title", "Delete Benefit");
}

function addDeleteUrlBenefit(x) {
    var benefitId = $(x).attr("benefit-id");
    var deleteUrl = "/Benefit/DeleteBenefit/";
    $("#deleteForm").attr("action", deleteUrl + benefitId);
}

//Delete Policy Modal
function initModalPolicy() {
    $("#myModalPolicy").attr("modal-title", "Delete Policy");
}

function addDeleteUrlPolicy(x) {
    var policyId = $(x).attr("policy-id");
    var deleteUrl = "/Policy/DeletePolicy/";
    $("#deleteForm").attr("action", deleteUrl + policyId);
}

//Delete Event Modal
function initModalEvent() {
    $("#myModalEvent").attr("modal-title", "Delete Event");
}

function addDeleteUrlEvent(x) {
    var eventId = $(x).attr("event-id");
    var deleteUrl = "/Event/DeleteEvent/";
    $("#deleteForm").attr("action", deleteUrl + eventId);
}

//Delete Event Category Modal
function initModalEventCategory() {
    $("#myModalEvent").attr("modal-title", "Delete EventCategory");
}

function addDeleteUrlEventCategory(x) {
    var eventCategoryId = $(x).attr("eventCategory-id");
    var deleteUrl = "/EventCategory/DeleteCategory/";
    $("#deleteForm").attr("action", deleteUrl + eventCategoryId);
}


//Files
function fileSelected() {

    // get selected file element

    var oFile = document.getElementById('image_file').files[0];

    // filter for image files

    var rFilter = /^(image\/bmp|image\/gif|image\/jpeg|image\/png|image\/tiff)$/i;

    if (! rFilter.test(oFile.type)) {

        document.getElementById('error').style.display = 'block';

        return;

    }

 

    // get preview element

    var oImage = document.getElementById('preview');

 

    // prepare HTML5 FileReader

    var oReader = new FileReader();

        oReader.onload = function(e){

 

        // e.target.result contains the DataURL which we will use as a source of the image

        oImage.src = e.target.result;




    };

 

    // read selected file as DataURL

    oReader.readAsDataURL(oFile);

}
