<template>
  <div id="app">
    <header>
      <b-navbar toggleable="sm" type="dark">
        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
        <b-navbar-brand to="/">Workout Tracker</b-navbar-brand>
        <b-collapse is-nav id="nav-collapse">
          <b-navbar-nav id="dropnav" >
            <b-nav-item to="/">Home</b-nav-item>
            <b-nav-item to="/workout-timer">Workout Timer</b-nav-item>
            <b-nav-item to="/weight-logger">Weight Log</b-nav-item>
          </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </header>
    <main>
      <router-view></router-view>
    </main>
  </div>
</template>

<script>
export default {
  name: 'app'
}
</script>


<style>
body {
  margin: 0;
  background: slategrey;
}

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

main {
  text-align: center;
  margin-top: 40px;
}

header {
  margin: 0;
  height: 56px;
  padding: 0 16px 0 24px;
  background-color: #1b232c;
  color: #ffffff;
}

header span {
  display: block;
  position: relative;
  font-size: 20px;
  line-height: 1;
  letter-spacing: .02em;
  font-weight: 400;
  box-sizing: border-box;
  padding-top: 16px;
}
</style>
