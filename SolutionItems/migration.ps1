function global:master-add-migration($migration_name) 
{
	add-migration $migration_name -c "MasterDbContext" -o "./Migrations/Master"
}

function global:master-remove-migration() 
{
	remove-migration -c "MasterDbContext"
}


function global:master-script-migration($from, $to)
{
    if($from)
    {
        script-migration -Context "MasterDbContext" -From $from
    }
    elseif($form -and $to)
    {
		script-migration -Context "MasterDbContext" -From $from -To $to 
        script-migration -Context "MasterDbContext" -From $from -To $to 
    }
    else
    {
        script-migration -Context "MasterDbContext"
    }
}


function global:tenant-add-migration($migration_name) 
{
	add-migration $migration_name -c "TenantDbContext" -o "./Migrations/Tenant"
}

function global:tenant-remove-migration() 
{
	remove-migration -c "TenantDbContext"
}
