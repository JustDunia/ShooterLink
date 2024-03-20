import * as React from 'react'
import AppBar from '@mui/material/AppBar'
import Box from '@mui/material/Box'
import CssBaseline from '@mui/material/CssBaseline'
import Divider from '@mui/material/Divider'
import Drawer from '@mui/material/Drawer'
import IconButton from '@mui/material/IconButton'
import AdminPanelSettingsIcon from '@mui/icons-material/AdminPanelSettings'
import List from '@mui/material/List'
import ListItem from '@mui/material/ListItem'
import ListItemButton from '@mui/material/ListItemButton'
import ListItemIcon from '@mui/material/ListItemIcon'
import ListItemText from '@mui/material/ListItemText'
import HomeIcon from '@mui/icons-material/Home'
import MenuIcon from '@mui/icons-material/Menu'
import Toolbar from '@mui/material/Toolbar'
import Typography from '@mui/material/Typography'
import { Suspense } from 'react'
import { Outlet } from 'react-router-dom'

const drawerWidth = 200

export default function SharedLayout() {
	const [mobileOpen, setMobileOpen] = React.useState(false)
	const [isClosing, setIsClosing] = React.useState(false)

	const handleDrawerClose = () => {
		setIsClosing(true)
		setMobileOpen(false)
	}

	const handleDrawerTransitionEnd = () => {
		setIsClosing(false)
	}

	const handleDrawerToggle = () => {
		if (!isClosing) {
			setMobileOpen(!mobileOpen)
		}
	}

	const drawer = (
		<div>
			<Toolbar />
			<Divider />
			<List>
				<ListItem key={'Home'} disablePadding>
					<ListItemButton>
						<ListItemIcon>
							<HomeIcon />
						</ListItemIcon>
						<ListItemText primary={'Home'} />
					</ListItemButton>
				</ListItem>
			</List>
			<Divider />
			<List>
				<ListItem key={'Admin Panel'} disablePadding>
					<ListItemButton>
						<ListItemIcon>
							<AdminPanelSettingsIcon />
						</ListItemIcon>
						<ListItemText primary={'Admin Panel'} />
					</ListItemButton>
				</ListItem>
			</List>
		</div>
	)

	return (
		<Box sx={{ display: 'flex' }}>
			<CssBaseline />
			<AppBar
				position='fixed'
				sx={{
					ml: { sm: `${drawerWidth}px` },
					zIndex: theme => theme.zIndex.drawer + 1,
				}}
			>
				<Toolbar>
					<IconButton
						color='inherit'
						aria-label='open drawer'
						edge='start'
						onClick={handleDrawerToggle}
						sx={{ mr: 2, display: { sm: 'none' } }}
					>
						<MenuIcon />
					</IconButton>
					<img src='../../public/target-icon-red.png' width={40} />
					<Typography variant='h6' noWrap component='div' sx={{ ml: 2 }}>
						ShooterLink
					</Typography>
				</Toolbar>
			</AppBar>
			<Box
				component='nav'
				sx={{ width: { sm: drawerWidth }, flexShrink: { sm: 0 } }}
				aria-label='mailbox folders'
			>
				{/* The implementation can be swapped with js to avoid SEO duplication of links. */}
				<Drawer
					variant='temporary'
					open={mobileOpen}
					onTransitionEnd={handleDrawerTransitionEnd}
					onClose={handleDrawerClose}
					ModalProps={{
						keepMounted: true,
					}}
					sx={{
						display: { xs: 'block', sm: 'none' },
						'& .MuiDrawer-paper': { boxSizing: 'border-box', width: drawerWidth },
					}}
				>
					{drawer}
				</Drawer>
				<Drawer
					variant='permanent'
					sx={{
						display: { xs: 'none', sm: 'block' },
						'& .MuiDrawer-paper': { boxSizing: 'border-box', width: drawerWidth },
					}}
					open
				>
					{drawer}
				</Drawer>
			</Box>
			<Box
				component='main'
				sx={{ flexGrow: 1, p: 3, width: { sm: `calc(100% - ${drawerWidth}px)` } }}
			>
				<Toolbar />
				<Suspense fallback={<div>Loading...</div>}>
					<Outlet />
				</Suspense>
			</Box>
		</Box>
	)
}
