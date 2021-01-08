function confirm(value,display)
{
    if(display)
    {
        $('#confirmDelete_'+value).show();
        $('#delete_'+value).hide();
    }
    else {
        $('#confirmDelete_'+value).hide();
        $('#delete_'+value).show();
    }
}