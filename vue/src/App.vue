<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.5/getting-started/introduction/ for reference on bootstrap -->
<template>
  <div id="app"> <!-- If you start to get random styling you don't like, remove container from this div -->
    <div id="nav">

<!--sidebar-->
    <div class="side">
    <nav id="sidebar">
      <div id="sidebar-content">
        <h3>Site Name?????</h3>
        <ul class="sidebar-navs">  
                <ul>
                 <li>
                  <router-link class="nav-item"
                  v-bind:to="{ name: 'home' }">
                   <i class="fas fa-home"></i> <!-- This is a font awesome icon -->
                   Home 
                  </router-link>
                 </li>
              <li>
              <router-link
               class="view-potholes"
               v-bind:to="{name: 'AllPotholes'}">
               <i class="fa-regular fa-car-burst"></i>
               View All Potholes
               </router-link>
               </li>
               <li>
               <router-link class="add-pothole"
                v-bind:to="{name: 'report'}">
                Report a Pothole</router-link>
              </li>
              <li>
             <router-link
               class="nav-item"
               id="register"
               v-bind:to="{ name: 'register' }"
               v-if="!$store.state.token"><button>Register</button></router-link>
              </li>
              <li>
                 <router-link
                class="nav-item"
                id="login"
                v-bind:to="{ name: 'login' }"
                v-if="!$store.state.token">
                  <button>Login</button>
                 </router-link>
              </li>
              <li>
               <router-link
                class="nav-item"
                id="logout"
               v-bind:to="{ name: 'logout' }"
               v-if="$store.state.token">
              <button>Logout</button>
              </router-link>
              </li>
      </ul>
      </ul>
      </div>
    </nav>
    </div>
    <!--sidebar-->

  <router-view />
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
html{
  background-color: #ede3d9;
}
#app{
  display: flex;
  justify-content: center;
  
}
.header{
  display: flex;
  //flex-grow: ;
  background-color: #af9d89;
}

.side{
  display: flex;
  justify-content: left;
  width: 100%;
}

#sidebar{
  width: 250px;
  position: fixed;
  top: 0;
  left: 0;
  height: 100vh;
  z-index: 999;
  background: #CCD5C4;
  color: #fff;
  transition: all 0.3s;
  border-right: 5px solid  #727A6B;
  font-size: 20px;
}

ul{
  list-style: none;
  display: flex;
  flex-direction: column;
}

li{
  display: flex;
  padding-bottom: 1rem;
  padding-top: 1rem;
}
h3{
  color: #1C2915;
}
#app{
  background-color: #af9d89;
}


</style>