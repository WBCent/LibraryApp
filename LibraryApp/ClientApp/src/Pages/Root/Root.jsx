import {AppBar, Box, Toolbar, Typography, Button} from "@mui/material";


const Root = () => {
    
    const loggedIn = false;
    
    return (
        <>
            <Box>
                <AppBar>
                    <Typography variant="h5">Library App</Typography>
                    {/*{loggedIn == true? (<Typography>Role: </Typography>) : (<Button variant="outlined">Log In</Button>)}*/}
                    <Button variant="contained">Log In</Button>
                </AppBar>
            </Box>
        </>
    )
}

export default Root;