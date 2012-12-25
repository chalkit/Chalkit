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

function ajaxDeleteCourse(deleteCourseUrl,coursesListUrl,message) {
    $.ajax({
        type: 'GET',
        url: deleteCourseUrl,
        success: function (result) {

            $.ajax({
                type: 'GET',
                url: coursesListUrl,
                success: function (resultCourses) {
                    $('.iconStyleListWrapper').html(resultCourses);
                }
            });


            var div = $('.partialViewFormDiv');
            var height = div.height();
            div.animate({ height: '0px', opacity: '0.0' }, "medium", function () {
                $('.courseForm').html(result);
                $('.message').html(message);
                $('.message').show();
            });
            div.animate({ height: height+40, opacity: '1.0' }, "medium");
        }
    });
}
