function ajaxChangeCourseForm(courseID)
{
    resultHTML = jQuery.ajax({
        type: 'GET',
        data: courseID,
        url: '/Author/EditCourse'
    }).responseText;

    $('.courseForm').html(resultHTML);
}

function redirectTo(url)
{
    window.location = url;
}