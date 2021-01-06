function AskForSure(userId,display)
{
    if(display)
    {
        $('#confirmDeleteSpan_'+userId).show();
        $('#deleteSpan_'+userId).hide();
    }
    else {
        $('#confirmDeleteSpan_'+userId).hide();
        $('#deleteSpan_'+userId).show();
    }
}