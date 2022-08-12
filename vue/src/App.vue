<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.5/getting-started/introduction/ for reference on bootstrap -->
<template>
  <div id="app">
    <!-- If you start to get random styling you don't like, remove container from this div -->
    <div id="nav">
      <!--navbar-->
      <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand" href="#"
          >HoleHuntr Premium <i class="far fa-kiss-wink-heart"></i
        ></a>
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

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav mr-auto">
            <li class="nav-item active">
              
              <router-link class="nav-link" v-bind:to="{ name: 'home' }">
                <i class="fas fa-home"></i>
                Home
              </router-link>
            </li>

            <li class="nav-item">
            
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
    </div>
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
#view-window {
  padding: 1rem;
}
</style>