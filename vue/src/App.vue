<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.5/getting-started/introduction/ for reference on bootstrap -->
<template>
  <div id="app"> <!-- If you start to get random styling you don't like, remove container from this div -->
    <div id="nav">
      <router-link class="nav-item" v-bind:to="{ name: 'home' }">
        <i class="fas fa-home"></i> <!-- This is a font awesome icon -->
        Home 
      </router-link>
    <router-view />

<!--sidebar-->
    <div>
    <nav id="sidebar">
      <div id="sidebar-content">
        <h3>Site Name?????</h3>
        <ul class="sidebar-navs"> 
          <a href="#homeSubmenu" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">Actions you can do</a>
                <ul class="collapse list-unstyled" id="homeSubmenu">
                <li>
                 <router-link
        class="nav-item"
        v-bind:to="{ name: 'login' }"
        v-if="!$store.state.token">
        <button>Login</button>
      </router-link>
      </li>
      <li>
        <router-link
        class="nav-item"
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token">
        <button>Logout</button>
      </router-link>
        </li>
        <li>
          <router-link
        class="nav-item"
        v-bind:to="{ name: 'register' }"
        v-if="!$store.state.token"><button>Register</button></router-link>
          </li>
                  <li>
                    <router-link
                    class="view-potholes"
                    v-bind:to="{name: 'AllPotholes'}">View All Potholes</router-link>
                    </li>
                    <li>
                      <router-link class="add-pothole"
                      v-bind:to="{name: 'report'}">Report a Pothole</router-link>
                    </li>
      </ul>
      </ul>
      </div>
    </nav>
    </div>
    <!--sidebar-->

    </div>
  </div>
</template>

<script>
export default {
  
}
</script>

<!-- Application-Wide Styles go here. 
     Any valid CSS or SCSS is allowable here. See https://sass-lang.com/documentation/style-rules for info on SCSS -->
<style lang="scss">

@import './styles/colors.scss';

// Import the bootstrap styles. If you want to override Bootstrap colors, it needs to happen above this line
@import '../node_modules/bootstrap/scss/bootstrap';

// Your custom styles go below this point

*{
  background-color: #ede3d9;
}



</style>