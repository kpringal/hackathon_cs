import * as React from 'react';
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import CssBaseline from '@mui/material/CssBaseline';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import List from '@mui/material/List';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import InboxIcon from '@mui/icons-material/MoveToInbox';
import MailIcon from '@mui/icons-material/Mail';
import Roles from '../Roles/Roles';
import FloorPlan from '../FloorPlan/FloorPlan';
import SpaceAllocation from '../SpaceAllocation/SpaceAllocation';
import { useEffect, useState } from 'react';
import DeskAllocation from '../DeskAllocation/DeskAllocation';
import { Navigate } from "react-router-dom";

const drawerWidth = 240;

function Home() {

  const [selectedItem,SetSelectedItem]=useState(0);
  const [authenticated, setauthenticated] = useState(true);

  useEffect(() => {
    const loggedInUser = localStorage.getItem("authenticated");
    if (loggedInUser) {
      setauthenticated(true);
    }
      }, []);

  if (!authenticated) {
    // Redirect
    return <Navigate replace to="/login" />;
    } 
  else {
    return (
      <Box sx={{ display: 'flex' }}>
      <CssBaseline />
      <AppBar position="fixed" sx={{ zIndex: (theme) => theme.zIndex.drawer + 1 }}>
        <Toolbar>
          <Typography variant="h6" noWrap component="div">
            Welcome {localStorage.getItem("userName")}
          </Typography>
        </Toolbar>
        
      </AppBar>
      <Drawer
        variant="permanent"
        sx={{
          width: drawerWidth,
          flexShrink: 0,
          [`& .MuiDrawer-paper`]: { width: drawerWidth, boxSizing: 'border-box' },
        }}
      >
        <Toolbar />
        <Box sx={{ overflow: 'auto' }}>
          <List>
            {['Roles', 'Floor Plan', 'Space Allocation', 'Desk Allocation'].map((text, index) => (
              <ListItem key={text} disablePadding>
                <ListItemButton onClick={()=>SetSelectedItem(index)}>
                  <ListItemIcon>
                    {index % 2 === 0 ? <InboxIcon /> : <MailIcon />}
                  </ListItemIcon>
                  <ListItemText primary={text} />
                </ListItemButton>
              </ListItem>
            ))}
          </List>
          <Divider />
        </Box>
      </Drawer>
        <Box
          component="main"
          sx={{ flexGrow: 1, bgcolor: 'background.default', p: 3 }}
        >
          <Toolbar />
          {
            selectedItem == 0 && <Roles></Roles>
          }
          {
            selectedItem == 1 &&<FloorPlan></FloorPlan>
          }
          {
            selectedItem == 2 &&<SpaceAllocation></SpaceAllocation>
          }
          {
            selectedItem == 3 && <DeskAllocation></DeskAllocation>
          }
        </Box>
      </Box>
    );
}
}


export default Home;
