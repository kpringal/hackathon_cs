import React, { FC, useEffect, useState } from 'react';
import styles from './SpaceAllocation.module.css';
import { Request } from '../../services/httpClient';
import { Box, FormControl, InputLabel, MenuItem, Select } from '@mui/material';

interface SpaceAllocationProps {}

function SpaceAllocation(){

  const date = new Date();
  const[spacedata , setSpaceData]=  useState();
  const[officedata , setofficedata]=  useState<any[]>([]);
  const[floordata , setFloordata]=  useState<any[]>([]);
  const[zonedata , setZonedata]=  useState<any[]>([]);


  useEffect( () => {
    const tdate = date.toISOString().split('T')[0];
    const payload ={
      userId : localStorage.getItem("userkey"),
      startAllocationDateTime : tdate,
      endAllocationDateTime : tdate
    }
  
    Request({url:'/SpaceAllocation/AllocatedSpaceForUser',method:"POST",data:payload}).then(
      function(res)
      {
        console.log(res);
        setSpaceData(res.data.allocatedSpaces);

        let office= new Set();
        let floor=new Set();
        let zone=new Set();
        res.data.allocatedSpaces.forEach((spaces: { officeName: any; floorName: any; zoneName: any; }) => {
          office.add(spaces.officeName);
          floor.add(spaces.floorName);
          zone.add(spaces.zoneName);
        });

        setofficedata(Array.from(office));
        setFloordata(Array.from(floor));
        setZonedata(Array.from(zone));

        
      }
    ).catch(
      function(err)
      {
        console.log(err);
      }
    );
  },[]);


  console.log(officedata);
  console.log(floordata);
  console.log(zonedata);
      return(
        <><Box sx={{ minWidth: 120 }}>
          <FormControl fullWidth>
            <InputLabel id="demo-simple-select-label">office</InputLabel>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              label="office"
            >
              {officedata.map((name) => (
                <MenuItem value={name}>
                  {name}
                </MenuItem>
              ))}

            </Select>
          </FormControl>
        </Box><Box sx={{ minWidth: 120 }}>
            <FormControl fullWidth>
              <InputLabel id="demo-simple-select-label">Floor</InputLabel>
              <Select
                labelId="demo-simple-select-label"
                id="demo-simple-select"
                label="Floor"
              >
                {floordata.map((name) => (
                  <MenuItem value={name}>
                    {name}
                  </MenuItem>
                ))}

              </Select>
            </FormControl>
          </Box>
          <Box sx={{ minWidth: 120 }}>
            <FormControl fullWidth>
              <InputLabel id="demo-simple-select-label">Zone</InputLabel>
              <Select
                labelId="demo-simple-select-label"
                id="demo-simple-select"
                label="Zone"
              >
                {floordata.map((name) => (
                  <MenuItem value={name}>
                    {name}
                  </MenuItem>
                ))}

              </Select>
            </FormControl>
          </Box></>
    );



}

export default SpaceAllocation;
