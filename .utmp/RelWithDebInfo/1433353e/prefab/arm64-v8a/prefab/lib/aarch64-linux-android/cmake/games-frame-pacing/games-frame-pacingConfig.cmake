if(NOT TARGET games-frame-pacing::swappy)
add_library(games-frame-pacing::swappy SHARED IMPORTED)
set_target_properties(games-frame-pacing::swappy PROPERTIES
    IMPORTED_LOCATION "C:/Users/Chuong/.gradle/caches/transforms-3/c06beefdf4305df6dd74bf257ec55657/transformed/jetified-games-frame-pacing-2.1.2/prefab/modules/swappy/libs/android.arm64-v8a/libswappy.so"
    INTERFACE_INCLUDE_DIRECTORIES "C:/Users/Chuong/.gradle/caches/transforms-3/c06beefdf4305df6dd74bf257ec55657/transformed/jetified-games-frame-pacing-2.1.2/prefab/modules/swappy/include"
    INTERFACE_LINK_LIBRARIES ""
)
endif()

if(NOT TARGET games-frame-pacing::swappy_static)
add_library(games-frame-pacing::swappy_static STATIC IMPORTED)
set_target_properties(games-frame-pacing::swappy_static PROPERTIES
    IMPORTED_LOCATION "C:/Users/Chuong/.gradle/caches/transforms-3/c06beefdf4305df6dd74bf257ec55657/transformed/jetified-games-frame-pacing-2.1.2/prefab/modules/swappy_static/libs/android.arm64-v8a/libswappy_static.a"
    INTERFACE_INCLUDE_DIRECTORIES "C:/Users/Chuong/.gradle/caches/transforms-3/c06beefdf4305df6dd74bf257ec55657/transformed/jetified-games-frame-pacing-2.1.2/prefab/modules/swappy_static/include"
    INTERFACE_LINK_LIBRARIES ""
)
endif()

