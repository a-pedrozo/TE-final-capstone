<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.5/getting-started/introduction/ for reference on bootstrap -->
<template>
  <div id="app">
    <!-- If you start to get random styling you don't like, remove container from this div -->
    <!-- <div id="nav"> -->
    <!--navbar-->
    <nav class="navbar navbar-expand-lg navbar-dark">
      <router-link class="navbar-brand" v-bind:to="{ name: 'home' }">
        <img src="@/images/logo_icon2.png" class="logo"><span id="logo-title">
        PotholeHuntr</span>
        <!-- HoleHuntr Premium <i class="far fa-kiss-wink-heart"></i> -->
      </router-link>
      <button
        class="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse links" id="navbarSupportedContent">
        <ul class="navbar-nav ml-auto">
          <li class="nav-item active">
            <router-link class="nav-link" v-bind:to="{ name: 'AllPotholes' }">
              <i class="fas fa-car-crash"></i>
              View All Potholes
            </router-link>
          </li>

          <li class="nav-item">
            <router-link
              class="nav-link"
              v-if="$store.state.token"
              v-bind:to="{ name: 'report' }"
            >
              <i class="fas fa-clipboard-list"></i>
              Report a Pothole</router-link
            >
          </li>

          <li class="nav-item dropdown">
            <a
              class="nav-link dropdown-toggle"
              href="#"
              id="navbarDropdown"
              role="button"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
            >
              Login/Logout
            </a>
            <div class="dropdown-menu" aria-labelledby="navbarDropdown">
              <router-link
                class="dropdown-item"
                id="register"
                v-bind:to="{ name: 'register' }"
                v-if="!$store.state.token"
                >Register
              </router-link>

              <router-link
                class="dropdown-item"
                id="login"
                v-bind:to="{ name: 'login' }"
                v-if="!$store.state.token"
              >
                Login
              </router-link>

              <router-link
                class="dropdown-item"
                id="logout"
                v-bind:to="{ name: 'logout' }"
                v-if="$store.state.token"
              >
                Logout
              </router-link>
            </div>
          </li>
          <!--<li class="nav-item">
        <a class="nav-link disabled" href="#">Disabled</a>
      </li>
    <form class="form-inline my-2 my-lg-0">
      <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
      <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
    </form>-->
        </ul>
      </div>
    </nav>

    <div id="view-window">
      <router-view />
    </div>
    <!-- </div> -->
  </div>
</template>

<script>
export default {};
</script>

<!-- Application-Wide Styles go here. 
     Any valid CSS or SCSS is allowable here. See https://sass-lang.com/documentation/style-rules for info on SCSS -->
<style lang="scss">
@import "./styles/colors.scss";

// Import the bootstrap styles. If you want to override Bootstrap colors, it needs to happen above this line
@import "../node_modules/bootstrap/scss/bootstrap";

// Your custom styles go below this point
#app {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  background-color: red;
  //background-color: #CFDDC4;
}

#view-window {
  padding: 1rem;
  margin: 1rem 1rem 1rem 1rem;
  background-color: #d3fca6;
background-image: url("https://www.transparenttextures.com/patterns/cartographer.png");
/* This is mostly intended for prototyping; please download the pattern and re-host for production environments. Thank you! */
  flex-grow: 1;
  height: auto;
  //padding-top: 3rem;

  margin: 0;
}
html {
<<<<<<< HEAD
 
=======
>>>>>>> 800ea48889aed4e0d48d7af8b9d0b2e115d36c8b
  height: 100%;
  width: 100%;
  background-color: #d3fca6;
  background-image: url("https://www.transparenttextures.com/patterns/cartographer.png");
/* This is mostly intended for prototyping; please download the pattern and re-host for production environments. Thank you! */
}

.navbar {
  background-color: #1c2915;
  color: #cfddc4;
  padding-bottom: 1rem;
  padding-top: 1rem;
  box-shadow: 0 2px 18px rgba(0, 0, 0, 0.25);
  border-bottom: 1px solid rgba(255, 255, 255, 0.3);

  // position: fixed;
  // top: 0;
  // left: 0;
  // right:0;
}
// @import url("https://fonts.google.com/specimen/Chivo");
// html{
//   font-family: Chivo;
// }
.navbar-brand{
  display: flex;
  align-items: center;
}
.inspect{
  font-style: italic;
}
.input-name{
  font-weight: bold;
}
.update-hole{
  padding-left: 3rem;
}
.logo{
  max-width: 75px;
  margin: 0 1rem;
}
#logo-title {
  font-size: 35px;
  font-weight: bold;
}

</style>