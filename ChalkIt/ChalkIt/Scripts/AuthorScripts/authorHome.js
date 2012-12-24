function ajaxChangeCourseForm(actionUrl)
{
    $.ajax({
        type: 'GET',
        url: actionUrl,
        success: function (result) {
            var div = $('.partialViewFormDiv');
            var height = div.height();
            div.animate({ height: '0px', opacity: '0.0' }, "medium", function(){
                $('.courseForm').html(result);
            });
            div.animate({ height: height, opacity: '1.0' }, "medium");
        }
    });

   
}
